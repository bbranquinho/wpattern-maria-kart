using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Encog.Engine.Network.Activation;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Microsoft.Win32;
using WColorSensor.Beans;
using WColorSensor.Networks;
using WColorSensor.Networks.Interfaces;

namespace WColorSensor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort Serial { get; set; }

        private MLP Mlp { get; set; }

        private AsyncObservableCollection Samples { get; set; }

        private IDictionary<string, double[]> Labels { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            Samples = new AsyncObservableCollection();
            DataGridColor.ItemsSource = Samples;
        }

        private void ButtonOpenSerialPort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Serial == null) || !Serial.IsOpen)
                {
                    Serial = new SerialPort(TextBoxSerialPort.Text, (int)ComboBoxBaudRate.SelectedItem)
                                 {
                                     DtrEnable = true
                                 };
                    Serial.DataReceived += SerialDataReceiver;
                    Serial.Open();
                    SerialConnectionOpen();
                }
                else
                {
                    Serial.Close();
                    SerialConnectionClosed();
                }
            }
            catch (Exception ex)
            {
                SerialConnectionClosed();
                MessageBox.Show(ex.Message);
            }
        }

        private void SerialDataReceiver(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort reader = (SerialPort)sender;

            AddSample(reader.ReadLine().Replace("\n", "").Replace("\r", ""));
        }

        private void SerialConnectionOpen()
        {
            ChangeComponentsStatus(true);
            ButtonOpenSerialPort.Content = "Close Connection";
        }

        private void SerialConnectionClosed()
        {
            ChangeComponentsStatus(false);
            ButtonOpenSerialPort.Content = "Open Connection";
        }

        private void ChangeComponentsStatus(bool value)
        {
            TextBoxSerialPort.IsEnabled = !value;
            ComboBoxBaudRate.IsEnabled = !value;
            LabelBaudRate.IsEnabled = !value;
            LabelPort.IsEnabled = !value;
            LabelBaudRate.IsEnabled = !value;
            ComboBoxBaudRate.IsEnabled = !value;

            LabelColor.IsEnabled = value;
            TextBoxColor.IsEnabled = value;
            LabelNumberSamples.IsEnabled = value;
            TextBoxNumberSamples.IsEnabled = value;
            TextBoxColorDelay.IsEnabled = value;
            LabelColorDelay.IsEnabled = value;
            LabelSampleDelay.IsEnabled = value;
            TextBoxSampleDelay.IsEnabled = value;
            ButtonReadSamples.IsEnabled = value;
        }

        private void ButtonReadSamples_Click(object sender, RoutedEventArgs e)
        {
            // Example => c:White:n:10:d:15:s:500
            Serial.Write(String.Format("c:{0}:n:{1}:d:{2}:s:{3}", TextBoxColor.Text, TextBoxNumberSamples.Text, TextBoxColorDelay.Text, TextBoxSampleDelay.Text));
        }

        private void ButtonClearSamples_Click(object sender, RoutedEventArgs e)
        {
            Samples.Clear();
        }

        private void ButtonTrainMLP_Click(object sender, RoutedEventArgs e)
        {
            double[][] inputs = BuildInput();
            double[][] outputs = BuildOutput();

            if (outputs.Length <= 0)
            {
                return;
            }

            int numberHiddenNeurons = inputs.Length;

            if (CheckBoxNumberHiddenNeurons.IsChecked == true)
            {
                if (!Int32.TryParse(TextBoxNumberHiddenNeurons.Text, out numberHiddenNeurons))
                {
                    numberHiddenNeurons = inputs.Length;
                }
            }

            Mlp = new MLP(3, numberHiddenNeurons, outputs[0].Length, Labels);

            Mlp.Train(inputs, outputs, new EpochListener(this));
        }

        private double[][] BuildInput()
        {
            double[][] inputs = new double[Samples.Count][];

            for (int i = 0; i < Samples.Count; i++)
            {
                inputs[i] = new double[] { Samples[i].R, Samples[i].G, Samples[i].B };
            }

            return inputs;
        }

        private double[][] BuildOutput()
        {
            Labels = BuildLabels();
            double[][] outputs = new double[Samples.Count][];

            for (int i = 0; i < Samples.Count; i++)
            {
                outputs[i] = Labels[Samples.ElementAt(i).Color];
            }

            return outputs;
        }

        private IDictionary<String, double[]> BuildLabels()
        {
            IDictionary<string, double[]> labels = new Dictionary<string, double[]>();
            IEnumerable<IGrouping<string, ColorBean>> groupedLabels = Samples.GroupBy(s => s.Color);
            int lenght = GetBinaryLenght(groupedLabels.Count());

            for (int i = 0; i < groupedLabels.Count(); i++)
            {
                labels.Add(groupedLabels.ElementAt(i).Key, ToBinary(i, lenght));
            }

            return labels;
        }

        private int GetBinaryLenght(int number)
        {
            for (int i = 14; i >= 0; i--)
            {
                if ((number & (1 << i)) != 0)
                {
                    return i + 1;
                }
            }

            return 1;
        }

        private double[] ToBinary(int number, int lenght)
        {
            double[] bits = new double[lenght];

            for (int i = lenght - 1; i >= 0; i--)
            {
                bits[i] = ((number & (1 << i)) == 0) ? 0 : 1;
            }

            return bits;
        }

        private void CheckBoxNumberHiddenNeurons_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxNumberHiddenNeurons.IsChecked == true)
            {
                TextBoxNumberHiddenNeurons.IsEnabled = true;
            }
            else
            {
                TextBoxNumberHiddenNeurons.IsEnabled = false;
            }
        }

        private void ButtonRemoveSamples_Click(object sender, RoutedEventArgs e)
        {
            Samples.RemoveAt(DataGridColor.SelectedIndex);
        }

        private void AddSample(String message)
        {
            // c:White:r:300:g:129:b:420
            string[] values = message.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                ColorBean color = new ColorBean(short.Parse(values[3]), short.Parse(values[5]), short.Parse(values[7]), values[1]);

                Samples.Add(color);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ButtonSaveSamples_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    StreamWriter file = new StreamWriter(saveFileDialog.FileName);

                    foreach (ColorBean sample in Samples)
                    {
                        //c:White:r:300:g:129:b:420
                        file.WriteLine(String.Format("c:{0}:r:{1}:g:{2}:b:{3}", sample.Color, sample.R, sample.G, sample.B));
                    }

                    file.WriteLine();

                    file.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ButtonLoadSamples_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter =  "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    StreamReader file = new StreamReader(openFileDialog.FileName);

                    while (!file.EndOfStream)
                    {
                        AddSample(file.ReadLine());
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ButtonTestMLP_Click(object sender, RoutedEventArgs e)
        {
            double[] input = new MLPInputWindow().ShowDialog();

            if (input != null)
            {
                TextBoxLog.Text += String.Format("Test Input R[{0}], G[{1}], B[{2}]\n", input[0], input[1], input[2]);

                TextBoxLog.Text += Mlp.Test(input) + "\n";
            }
        }

        public class EpochListener : IEpochListener
        {
            private MainWindow MainWindow { get; set; }

            public EpochListener(MainWindow mainWindow)
            {
                MainWindow = mainWindow;
            }

            public bool OnEpoch(int epoch, ITrain train)
            {
                MainWindow.TextBoxLog.Text += "Epoch " + epoch + ", Error: " + train.Error + "\n";

                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Encog.Engine.Network.Activation;
using Encog.ML.Train.Strategy;
using Encog.Neural.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Neural.NeuralData;
using WColorSensor.Networks.Interfaces;

namespace WColorSensor.Networks
{
    public class MLP : BasicNetwork
    {
        public IDictionary<String, double[]> Labels { get; private set; }

        public Int32 OutputSize { get; private set; }


        public MLP(int numInputsNeurons, int numHiddenNeurons, int numOutputNeurons, IDictionary<String, double[]> labels)
        {
            OutputSize = numOutputNeurons;
            Labels = labels;

            ILayer inputLayer = new BasicLayer(new ActivationTANH(), true, numInputsNeurons);
            ILayer hiddenLayer = new BasicLayer(new ActivationTANH(), true, numHiddenNeurons);
            ILayer outputLayer = new BasicLayer(new ActivationBiPolar(), false, numOutputNeurons);

            AddLayer(inputLayer);
            AddLayer(hiddenLayer);
            AddLayer(outputLayer);

            Structure.FinalizeStructure();
            Reset();
        }

        public void Train(double[][] inputs, double[][] outputs)
        {
            Train(inputs, outputs, new DefaultEpochListener());
        }

        public void Train(double[][] inputs, double[][] outputs, IEpochListener listener)
        {
            INeuralDataSet trainDataSet = new BasicNeuralDataSet(inputs, outputs);
            ITrain train = new Backpropagation(this, trainDataSet);
            StopTrainingStrategy stopTrainingStrategy = new StopTrainingStrategy();
            int epoch = 0;

            train.AddStrategy(stopTrainingStrategy);

            do {
                train.Iteration();
                epoch++;
            } while (!listener.OnEpoch(epoch, train) && !stopTrainingStrategy.ShouldStop());
        }

        public String Test(double[] input)
        {
            double[] output = new double[OutputSize];

            this.Compute(input, output);

            foreach (KeyValuePair<string, double[]> label in Labels)
            {
                String labelFounded = label.Key;

                for (int i = 0; i < label.Value.Length; i++)
                {
                    if (label.Value[i] != output[i])
                    {
                        labelFounded = null;
                    }
                }

                if (labelFounded != null)
                {
                    return labelFounded;
                }
            }

            return "Unknown";
        }

        private class DefaultEpochListener : IEpochListener
        {
            public bool OnEpoch(int epoch, ITrain train)
            {
                System.Diagnostics.Debug.WriteLine("Epoch " + epoch + ", Error: " + train.Error);

                return false;
            }
        }
    }
}
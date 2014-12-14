using Encog.Neural.Networks.Training;

namespace WColorSensor.Networks.Interfaces
{
    public interface IEpochListener
    {
        bool OnEpoch(int epoch, ITrain train);
    }
}
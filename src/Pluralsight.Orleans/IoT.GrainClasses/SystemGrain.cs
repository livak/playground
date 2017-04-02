using IoT.GrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoT.GrainInterfaces.Messages;
using IoT.GrainInterfaces.Observers;

namespace IoT.GrainClasses
{
    public class SystemGrain : Grain, ISystemGrain
    {
        Dictionary<long, double> temperatures;

        ObserverSubscriptionManager<ISystemObserver> observers;

        public override Task OnActivateAsync()
        {
            temperatures = new Dictionary<long, double>();
            observers = new ObserverSubscriptionManager<ISystemObserver>();
            var timer = RegisterTimer(Callback, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
            return base.OnActivateAsync();
        }

        Task Callback(object callbackState)
        {
            double value = GetAverageTemperature();
            if (value > 100)
            {
                observers.Notify(x => x.HighTemperature(value, this.GetPrimaryKeyString(), temperatures.Count));
            }

            return TaskDone.Done;
        }

        private double GetAverageTemperature()
        {
            return temperatures.Any() ? temperatures.Values.Average() : 0;
        }

        public Task SetTemperature(TemperatureReading reading)
        {
            temperatures[reading.DeviceId] = reading.Value;
            return TaskDone.Done;
        }

        public Task Subscribe(ISystemObserver observer)
        {
            observers.Subscribe(observer);
            return TaskDone.Done;
        }

        public Task UnSubscribe(ISystemObserver observer)
        {
            observers.Unsubscribe(observer);
            return TaskDone.Done;
        }

        public Task<double> GetTemperature()
        {
            return Task.FromResult(GetAverageTemperature());

        }
    }
}

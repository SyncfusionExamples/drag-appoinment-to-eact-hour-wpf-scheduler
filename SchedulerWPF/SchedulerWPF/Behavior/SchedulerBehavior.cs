using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Windows;

namespace WpfScheduler
{
    public class SchedulerBehavior : Behavior<SfScheduler>
    {
        SfScheduler scheduler;
        protected override void OnAttached()
        {
            base.OnAttached();
            scheduler = this.AssociatedObject;
            this.AssociatedObject.AppointmentDropping += AssociatedObject_AppointmentDropping;
        }
        private void AssociatedObject_AppointmentDropping(object sender, AppointmentDroppingEventArgs e)
        {
            var dropTime = e.DropTime;
            e.DropTime = new DateTime(dropTime.Year, dropTime.Month, dropTime.Day, dropTime.Hour, 0, 0);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.AppointmentDropping -= AssociatedObject_AppointmentDropping;
            this.scheduler = null;
        }
    }
}

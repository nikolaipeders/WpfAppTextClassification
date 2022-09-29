using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WpfAppTextClassification.Tools;

namespace WpfAppTextClassification.ViewModel
{
    public class TrainerViewModel : Bindable
    {
        private string _timespan = "00:00:00";
        private static string _infoText = "";
        public static TimeSpan ts = new TimeSpan();
        public static DispatcherTimer timer = new DispatcherTimer();
        public static Stopwatch stopWatch = new Stopwatch();

        public TrainerViewModel()
        {

            InfoText = "Training ...";

            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += stopwatchRunner;
            timer.Start();
        }

        public string TimeSpanText
        {
            get
            {
                return _timespan;
            }
            set
            {
                _timespan = value;
                propertyIsChanged();
            }
        }

        public static string InfoText
        {
            get
            {
                return _infoText;
            }
            set
            {
                _infoText = value;
            }
        }

        public void stopwatchRunner(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                ts = stopWatch.Elapsed;
                TimeSpanText = ts.ToString("mm':'ss':'ff");
            }
            else
            {
                stopWatch.Restart();
            }
        }
    }
}

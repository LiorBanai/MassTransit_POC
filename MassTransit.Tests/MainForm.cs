using System.ComponentModel;

namespace MassTransit.Tests
{
    public partial class MainForm : Form
    {
        private IGenericDataProducer<SystemEvent> _producer;
        private ISystemEventConsumer _consumer;
        private Task _task;
        private ProgressReporter<int> uiProducerReporter;
        private ProgressReporter<int> uiConsumerReporter;

        private int? last;
        public MainForm()
        {
            InitializeComponent();
            uiProducerReporter = new ProgressReporter<int>(p => rproducer.Text += $"{p} ");
            uiConsumerReporter = new ProgressReporter<int>(p =>
            {
                rconsumer.Text += $"{p} ";
                if (last.HasValue)
                {
                    if (p - last.Value > 1)
                    {
                        rconsumer.Text += $"Diff: {p - last.Value} ";
                    }
                }

                last = p;
            });
        }
        public MainForm(IGenericDataProducer<SystemEvent> producer) : this()
        {
            _producer = producer;
        }
        public MainForm(IGenericDataProducer<SystemEvent> producer, ISystemEventConsumer consumer) : this()
        {
            _producer = producer;
            _consumer = consumer;
        }

        private void btnProducer_Click(object sender, EventArgs e)
        {
            _task = Task.Run(() =>
            {
                int counter = 1;
                while (true)
                {
                    SystemEvent se = new SystemEvent(SystemEventType.AFResultEvent,
                        DateTimeOffset.Now.ToUnixTimeMilliseconds(), (counter).ToString());
                    _producer.Publish(se);
                    uiProducerReporter.Report(counter);
                    counter++;
                    Thread.Sleep(1000);
                }
            });
        }

        private void btnConsumer_Click(object sender, EventArgs e)
        {

            _consumer.OnNewSystemEvent += (s, arg) =>
            {
                int p = int.Parse(arg.EventData);
                uiConsumerReporter.Report(p);
            };
        }


    }
}
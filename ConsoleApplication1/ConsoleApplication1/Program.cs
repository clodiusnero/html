using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyColletions
{
    using System.Collections;
    public delegate void ChangedEvenetHandler(object sender, EventArgs e);

    public class ListWithChangedEvenet : ArrayList
    {
        public event ChangedEvenetHandler Changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        public override int Add(object value)
        {
            int i = base.Add(value);
            OnChanged(EventArgs.Empty);
            return i;
        }

        public override void Clear()
        {
            base.Clear();
            OnChanged(EventArgs.Empty);
        }

        public override object this[int index]
        {
            set
            {
                base[index] = value;
                OnChanged(EventArgs.Empty);
            }
        }
    }
}

namespace TestEvents
{
    using MyColletions;

    class EventListener
    {
        private ListWithChangedEvenet List;

        public EventListener(ListWithChangedEvenet list)
        {
            List = list;
            List.Changed += new ChangedEvenetHandler(ListChanged);
        }

        private void ListChanged(object sender, EventArgs e)
        {
            Console.WriteLine("This is called when the event fires.");
        }

        public void Detach()
        {
            List.Changed -= new ChangedEvenetHandler(ListChanged);
            List = null;
        }
    }

    class Test
    {
        public static void Main()
        {
            ListWithChangedEvenet list = new ListWithChangedEvenet();

            EventListener listener = new EventListener(list);

            list.Add("item 1");
            list.Clear();
            listener.Detach();
            Console.ReadKey();
        }
    }
}
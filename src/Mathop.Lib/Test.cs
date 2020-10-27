namespace Mathop.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Test : IEnumerable<Equation>
    {
        public int ElapsedMilliseconds { get; private set; }

        private List<Equation> _equations = new List<Equation>();
        private List<Answer> _answers = new List<Answer>();
        private Stopwatch _stopwatch = new Stopwatch();

        private DateTime _createdDateTime;

        public Test()
        {
            _createdDateTime = DateTime.Now;
        }

        public long EllapsedMilliseconds
        {
            get
            {
                return _stopwatch.ElapsedMilliseconds;
            }
        }

        public Equation this[int index]
        {
            get { return _equations[index]; }
            set { _equations.Insert(index, value); }
        }

        public IEnumerator<Equation> GetEnumerator()
        {
            return _equations.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void AddEquation(Equation equation)
        {
            _equations.Add(equation);
        }

        public void Start()
        {
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBikes_1830508.Bus
{
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public Date()
        {
            this.day = 00;
            this.month = 00;
            this.year = 00;
        }

        public Date(int month, int day, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }
        
        public override string ToString()
        {
            string state;
            state = this.day + "/" + this.month + "/" + this.year;
            return state;
        }
    }
}

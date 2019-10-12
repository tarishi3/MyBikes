using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBikes_1830508.Bus
{
    public enum EnumColor
    {
        Undefined,Red,Green,Blue,Black
    }
    public enum EnumRimType
    {
        Undefined,Standard,Alloy
    }
    public enum EnumSusType
    {
        Not_Applicable, Front, Rear, Front_Rear
    }
    public enum EnumModelType
    {
        Undefined, Mountain_Bikes, Road_Bikes
    }
    [Serializable]
    public class Bicycle
    {       
        private int serialNo;
        private EnumRimType rType;
        private EnumColor color;
        private string madeBy;
        private double price;
        private int speed;
        private double groundClearance;
        private double seatHeight;
        private EnumSusType suspensionType;
        private EnumModelType model;
        private Date date;      

        public Bicycle()
        {
            this.serialNo = 0;
            this.RimType = EnumRimType.Undefined;
            this.color = EnumColor.Undefined;
            this.madeBy = "Undefined";
            this.price = 0.00;
            this.speed = 0;
            this.groundClearance = 0.00;
            this.seatHeight = 0.00;
            this.suspensionType = EnumSusType.Not_Applicable;
            this.model = EnumModelType.Undefined;
            
               
        }
        public Bicycle( int serNo,EnumRimType rimTyp,EnumColor col,string madeby,double price,
                        int speed,double groundClr,double seatHgt,EnumSusType susType,EnumModelType model)
        {
            this.serialNo = serNo;
            this.RimType = rimTyp;
            this.color = col;
            this.madeBy = madeby;
            this.price = price;
            this.speed = speed;
            this.groundClearance = groundClr;
            this.seatHeight = seatHgt;
            this.suspensionType = susType;
            this.model = model;
        }

        public int Serial { get => serialNo; set => serialNo = value; }
        public EnumRimType RimType { get => rType; set => rType = value; }
        public EnumColor Color { get => color; set => color = value; }
        public string Madeby { get => madeBy; set => madeBy = value; }       
        public double Price { get => price; set => price = value; }
        public int Speed { get => speed; set => speed = value; }
        public double GroundClearance { get => groundClearance; set => groundClearance = value; }
        public double SeatHeight { get => seatHeight; set => seatHeight = value; }
        public EnumSusType SuspType { get => suspensionType; set => suspensionType = value; }
        public EnumModelType Model { get => model; set => model = value; }
        public Date MadeDate { get => date; set => date = value; }

        public Date Date
        {
            get => default(Date);
            set
            {
            }
        }

        public FileHandler FileHandler
        {
            get => default(FileHandler);
            set
            {
            }
        }

        internal LoginClass LoginClass
        {
            get => default(LoginClass);
            set
            {
            }
        }

        public EnumRimType EnumRimType
        {
            get => default(EnumRimType);
            set
            {
            }
        }

        public EnumModelType EnumModelType
        {
            get => default(EnumModelType);
            set
            {
            }
        }

        public EnumColor EnumColor
        {
            get => default(EnumColor);
            set
            {
            }
        }

        public EnumSusType EnumSusType
        {
            get => default(EnumSusType);
            set
            {
            }
        }

        public override string ToString()
        {
            String state;
            state =  this.Serial +"      "+ this.Madeby + "    \t" + this.Price + "$\t" + this.Speed + "Kph\t" 
                    + this.Color + "\t" + this.MadeDate + "    " + this.RimType + "\t" + this.Model + "\t" 
                    + this.SuspType + "\t" + this.GroundClearance + "mm\t\t" +this.SeatHeight + "mm";
            return state;
        }
    }
}

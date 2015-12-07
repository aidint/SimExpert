using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimExpert
{
    public class Inventory : Actor
    {
        private Discrete _State_Cumulative_Prob;
        private Dictionary<double, Discrete> _Demand_Cumulative_Prob;
        private TimeSpan _period;
        private Int64 _level;
        private Int64 _quantity;
        private double _current_state;
        private Int64 _demand;
        private double _price_per_unit;
        private double _sale_price_per_unit;
        private double _scrap_price_per_unit;
        private ResourceStatistic _statistics;
        private Int64 _current_cycle = 1;
        private bool _salvage = false;
        public ResourceStatistic Statistics
        {
            get { return _statistics; }
            set { _statistics = value; }
        }
        public double ScrapPricePerUnit
        {
            get { return _scrap_price_per_unit; }
            set { _scrap_price_per_unit = value; }
        }

        public double SalePricePerUnit
        {
            get { return _sale_price_per_unit; }
            set { _sale_price_per_unit = value; }
        }

        public double PricePerUnit
        {
            get { return _price_per_unit; }
            set { _price_per_unit = value; }
        }

        public Int64 Demand
        {
            get { return _demand; }
        }

        public double CurrentState
        {
            get { return _current_state; }
        }

        public Int64 Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public Int64 Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public TimeSpan Period
        {
            get { return _period; }
            set { _period = value; }
        }
        public Discrete StateProb
        {
            get { return _State_Cumulative_Prob; }
            set { _State_Cumulative_Prob = value; }
        }
        public Dictionary<double, Discrete> DemandProb
        {
            get { return _Demand_Cumulative_Prob; }
            set { _Demand_Cumulative_Prob = value; }
        }

        public Inventory(Environment env, Int64 Id, TimeSpan Period, Int64 Level, Discrete State, Dictionary<double, Discrete> Demand, double PricePerUnit, double SalePricePerUnit, bool Salvage, double ScrapPricePerUnit, List<double> CumulativeNext = null)
            : base(env, Id, CumulativeNext)
        {
            this.Period = Period;
            this.StateProb = State;
            if (Demand.Keys.Count != State.Probabilities.Count) throw new Exception("Demand Probabilities have problem in assigning");
            this.DemandProb = Demand;
            this.Level = Level;
            this.PricePerUnit = PricePerUnit;
            this.SalePricePerUnit = SalePricePerUnit;
            this.ScrapPricePerUnit = ScrapPricePerUnit;
            this._salvage = Salvage;
            this._statistics = new ResourceStatistic();
            this.Env.resource_statistics.Add(this.Statistics);
        }
        public override void Process(Event.Type T, Entity E,Actor A=null)
        {
            //////Console.WriteLine("Entity" + E.Id + " Entered Inventory" + this.AID + " for loading");

            Int64 LoadNeed = Level - Quantity;
            if (Quantity < Level)
            {
                if (LoadNeed <= E.Amount)
                {
                    Quantity = Level;
                    E.Amount = E.Amount - LoadNeed;
                }
                else throw new Exception("Not enough stock for Inventory(Id=" + AID);
            }
            ////////Console.WriteLine("Inventory" + this.AID  + " loaded " + LoadNeed + " units");

            base.CallNext(E);

            
            
            _current_state = StateProb.NextDouble();
            _demand = (Int64)DemandProb[_current_state].NextDouble();
                
            
            double Revenue = (_demand <= _quantity ? _demand : _quantity) * SalePricePerUnit;
            double LostProfit = (_demand >= _quantity ? _demand - _quantity : 0) * (SalePricePerUnit-PricePerUnit);
            double Scrap = 0;
            double LoadCost = LoadNeed * PricePerUnit;
            
            _quantity = _demand >= _quantity ? 0 : _quantity - _demand;
            
            if (_salvage) {
                Scrap = _quantity * ScrapPricePerUnit;
                _quantity = 0;
            }
            double Profit = Revenue - PricePerUnit * _level - LostProfit + Scrap;
            

            ResourceOtherStatistics RevStat = new ResourceOtherStatistics() { StatisticTitle = "Revenue", StatisticValue = Revenue };
            ResourceOtherStatistics LostStat = new ResourceOtherStatistics() { StatisticTitle = "Lost Profit", StatisticValue = LostProfit };
            ResourceOtherStatistics ScrapStat = new ResourceOtherStatistics() { StatisticTitle = "Salvage of Scrap", StatisticValue = Scrap };
            ResourceOtherStatistics ProfitStat = new ResourceOtherStatistics() { StatisticTitle = "Profit", StatisticValue = Profit };
            ResourceOtherStatistics DemandStat = new ResourceOtherStatistics() { StatisticTitle = "Demand", StatisticValue = _demand };
            ResourceOtherStatistics StateStat = new ResourceOtherStatistics() { StatisticTitle = "State", StatisticValue = _current_state };


            ResourceOtherStatistics[] Stats = new ResourceOtherStatistics[] {StateStat,DemandStat,RevStat,LostStat,ScrapStat,ProfitStat };

            Statistics.OtherStatistics.Add(_current_cycle, Stats);
            //////Console.WriteLine("Inventory" + this.AID + " ended cycle" + _current_cycle);
            _current_cycle++;
            
            

        }
        public override void GenerateEvent(Entity E)
        {
            Env.FEL.Enqueue(
                        Env.System_Time, new Event(Event.Type.L, Env.System_Time, this, Env, E)
                        );
        }
    }
}

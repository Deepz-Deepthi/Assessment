namespace Question4
{
    interface IBroadbandPlan
    {
        int GetBroadPlanAmount();
    }
    class Black : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private readonly int PlanAmount = 3000;
        public Black(bool isSubscriptionValid, int discountPercentage)
        {
            
            if(discountPercentage < 0 || discountPercentage > 50)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this._discountPercentage = discountPercentage;
                this._isSubscriptionValid = isSubscriptionValid;
            }
        }

        public int GetBroadPlanAmount()
        {
            int disPrice = 0;
            if (_isSubscriptionValid==true)
            {
                disPrice = PlanAmount - (PlanAmount * _discountPercentage / 100);
                return disPrice;
            }
            else
            {
                disPrice = PlanAmount;
                return disPrice;
            }
        }
    }
    class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private readonly int PlanAmount = 1500;
        public Gold(bool isSubscriptionValid, int discountPercentage)
        {

            if (discountPercentage < 0 || discountPercentage > 30)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this._discountPercentage = discountPercentage;
                this._isSubscriptionValid = isSubscriptionValid;
            }
        }
        public int GetBroadPlanAmount()
        {
            int disPrice = 0;
            if (_isSubscriptionValid == true)
            {
                disPrice = PlanAmount - (PlanAmount * _discountPercentage / 100);
                return disPrice;
            }
            else
            {
                disPrice = PlanAmount;
                return disPrice;
            }
        }
    }
    class SubscribePlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;
        public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
        {
            if(!(broadbandPlans == null))
            {
                this._broadbandPlans = broadbandPlans;
            }
            else
            {
                throw new ArgumentException();
            }
        }
     public  IList<Tuple<string,int>> GetSubscriptionPlan()
        {
            if (_broadbandPlans == null)
            {
                throw new ArgumentNullException();
            }

            IList<Tuple<string,int>> list = new List<Tuple<string,int>>();
            foreach(var i in _broadbandPlans)
            {
               if(i is Black)
                {
                    list.Add(new Tuple<string,int>("Black", i.GetBroadPlanAmount()));   
                }
                else
                {
                    list.Add(new Tuple<string, int>("Gold", i.GetBroadPlanAmount()));

                }
            }
           
            return list;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true,50),
                new Black(false,10),
                new Gold(true,30),
                new Black(true,20),
                new Gold(false,20)
            };
            var subscriptionPlans = new SubscribePlan(plans);
            var result = subscriptionPlans.GetSubscriptionPlan();
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Item1},{item.Item2}");
            }
        }
    }
}

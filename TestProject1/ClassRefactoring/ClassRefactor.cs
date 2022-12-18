/*using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public static Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return Type switch
            {
                SwallowType.African when Load == SwallowLoad.None => 22,
                SwallowType.African when Load == SwallowLoad.Coconut => 18,
                SwallowType.European when Load == SwallowLoad.None => 20,
                SwallowType.European when Load == SwallowLoad.Coconut => 16,
                _ => throw new InvalidOperationException()
            };
        }
    }
}*/

using System.Collections.Generic;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        private static readonly Dictionary<(SwallowType, SwallowLoad), int> AirspeedVelocityValues = new Dictionary<(SwallowType, SwallowLoad), int>
        {
            { (SwallowType.African, SwallowLoad.None), 22 },
            { (SwallowType.African, SwallowLoad.Coconut), 18 },
            { (SwallowType.European, SwallowLoad.None), 20 },
            { (SwallowType.European, SwallowLoad.Coconut), 16 }
        };

        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public int GetAirspeedVelocity()
        {
            return AirspeedVelocityValues[(Type, Load)];
        }
    }
}
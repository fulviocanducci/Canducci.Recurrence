namespace Canducci.Recurrence.Models
{
    public sealed class Body
    {       
        public Body(string name, int interval, int? repeats)
        {
            Name = name;
            Interval = interval;
            Repeats = repeats;
        }
        private string name = string.Empty;
        private int? repeats = null;
        private int interval = 1;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new System.FormatException("Mínimo de 1 caractere e máximo de 255 caracteres.");
                }
                if (value.Length <= 0 || value.Length > 255)
                {
                    throw new System.FormatException("Mínimo de 1 caractere e máximo de 255 caracteres.");
                }
                name = value;
            }
        }

        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                if (value <= 0 || value > 12)
                {
                    throw new System.FormatException("Mínimo de 1 mês e máximo de 24 meses.");
                }
                interval = value;
            }
        }
        
        public int? Repeats
        {
            get
            {
                return repeats;
            }
            set
            {
                if (value.HasValue)
                {
                    if (value < 2 || value > 120)
                    {
                        throw new System.FormatException("Mínimo de 2 e máximo de 120.");
                    }
                }
                repeats = value;
            }
        }

        public dynamic ToObject()
        {
            return new
            {
                name = Name,
                repeats = Repeats,
                interval = Interval
            };
        }
    }
}

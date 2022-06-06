namespace PAS.Application.Attributes
{
    public class CustomAttribute : Attribute
    {
        public CustomAttribute()
        {
            //Default values

        }

        /// <summary>
        /// Is necesary validate?
        /// </summary>
        public bool Validate { get; set; }

        /// <summary>
        /// Message to show in validation
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Code to show in validation
        /// </summary>
        public string? Code { get; set; }
    }
}

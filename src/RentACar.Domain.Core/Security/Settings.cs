namespace RentACar.Domain.Core.Security
{
    public class Settings
    {
        protected Settings() { }
        
        /// <summary>
        /// Random string generator
        /// http://www.unit-conversion.info/texttools/random-string-generator/
        /// </summary>
        public static readonly string SecretKey = "rpe1orn0c6idfdn6inrd2160c0noo9fr";

        /// <summary>
        /// Encode to Base64 format
        /// https://www.base64encode.org/
        /// </summary>
        public static readonly string SecretKeyBase64 = "cnBlMW9ybjBjNmlkZmRuNmlucmQyMTYwYzBub285ZnI=";
    }
}

namespace CP.Abstractions.Helpers
{
    public static class ValidateJson
    {
        public static bool IsValidJson(this string strInput)
        {
            try
            {
                //using system.text.json intentionally because it is stricter than newtonsoft.json for json validation
                using var doc = System.Text.Json.JsonDocument.Parse(strInput);
                return true;
            }
            catch (System.Text.Json.JsonException)
            {
                return false;
            }
            catch (Exception ex) //Some other exception
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}

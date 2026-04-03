namespace AgroMarketplace.Api.Constants
{
    public static class CategoryNames
    {
        public const string Grains = "Grains";       // Grãos (Milho, Soja, etc)
        public const string Produce = "Produce";     // Hortifruti (Frutas, Verduras, Legumes)
        public const string Dairy = "Dairy";         // Laticínios (Queijos, Leite, Ovos)
        public const string Artisanal = "Artisanal"; // Artesanais (Mel, Geleias, Conservas)
        public const string Plants = "Plants";       // Mudas, Cactos, Plantas
        public const string Others = "Others";       // Outros

        public static readonly string[] AllCategories =
        {
            Grains, Produce, Dairy, Artisanal, Plants, Others
        };

        public static bool IsValid(string category)
        {
            return AllCategories.Any(c => c.Equals(category, StringComparison.OrdinalIgnoreCase));
        }
    }
}
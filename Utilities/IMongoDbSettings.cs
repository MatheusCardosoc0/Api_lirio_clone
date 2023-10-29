namespace Api.Utilities
{

    public class CollectionGroups
    {
        public PessoalCollections PESSOAL { get; set; }
        public MateriaisCollections MATERIAIS { get; set; }
        public FinanceiroCollections FINANCEIRO { get; set; }
        public UtilitariosCollections UTILITARIOS { get; set; }
    }

    public class PessoalCollections
    {
        public string Person { get; set; }
        public string Group { get; set; }
        public string City { get; set; }
    }

    public class MateriaisCollections
    {
        public string GroupProduct { get; set; }
        public string Product { get; set; }
    }

    public class FinanceiroCollections
    {
        public string PaymentTerms { get; set; }
        public string Coins { get; set; }
    }

    public class UtilitariosCollections
    {
        public string UserSystem { get; set; }
    }
}

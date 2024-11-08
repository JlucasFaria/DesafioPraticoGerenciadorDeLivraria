namespace DesafioPraticoGerenciadorDeLivraria.Communication.Requests;

public class RequestRegisterBook
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author {  get; set; } = string.Empty;
    public string Genre {  get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int QuantityAvailable { get; set; }
}

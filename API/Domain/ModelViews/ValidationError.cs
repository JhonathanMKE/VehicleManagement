namespace vehicle_management.Domain.ModelViews;

public struct ValidationError
{
    public List<string> Mensagem { get; set; }

    public ValidationError()
    {
        Mensagem = new List<string>();
    }

}
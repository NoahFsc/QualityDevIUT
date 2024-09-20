namespace TP1_QDev;

public class Livre : Media
{
    public string Auteur { get; set; }
    public int NombreDePages { get; set; }
    
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Auteur: {Auteur}, Nombre de Pages: {NombreDePages}");
    }
}
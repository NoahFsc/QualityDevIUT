namespace TP1_QDev;

public class CD : Media
{
    public string Artiste { get; set; }
    public int NombreDePistes { get; set; }
    
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Artiste: {Artiste}, Nombre de Pistes: {NombreDePistes}");
    }
}
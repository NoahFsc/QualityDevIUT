namespace TP1_QDev;

public class DVD : Media
{
    public string Realisateur { get; set; }
    public int Duree { get; set; }
    
    public override void AfficherInfos()
    {
        base.AfficherInfos();
        Console.WriteLine($"Réalisateur: {Realisateur}, Durée: {Duree} minutes");
    }
}
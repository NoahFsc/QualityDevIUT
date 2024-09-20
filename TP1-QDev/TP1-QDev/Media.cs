namespace TP1_QDev;

public class Media
{
    public string Titre { get; set; }
    public int NumeroDeReference { get; set; }
    public int NombreDExemplairesDisponibles { get; set; }
    
    public virtual void AfficherInfos()
    {
        Console.WriteLine($"Titre: {Titre}, Numéro de Référence: {NumeroDeReference}, Nombre d'Exemplaires Disponibles: {NombreDExemplairesDisponibles}");
    }
    
    // Surcharge de l'opérateur + pour ajouter des exemplaires
    public static Media operator +(Media media, int quantite)
    {
        media.NombreDExemplairesDisponibles += quantite;
        return media;
    }

    // Surcharge de l'opérateur - pour retirer des exemplaires
    public static Media operator -(Media media, int quantite)
    {
        if (media.NombreDExemplairesDisponibles < quantite)
        {
            throw new InvalidOperationException("Nombre d'exemplaires disponibles insuffisant.");
        }
        media.NombreDExemplairesDisponibles -= quantite;
        return media;
    }
}
using System.Text.Json;
namespace TP1_QDev;

public class Library
{
    public List<Media> Medias { get; set; } = new List<Media>();
    public List<Emprunt> Emprunts { get; set; } = new List<Emprunt>();
    public Media this[int numeroReference]
    {
        get
        {
            return Medias.FirstOrDefault(media => media.NumeroDeReference == numeroReference);
        }
    }
    
    public void AjouterMedia(Media media)
    {
        Medias.Add(media);
    }
    
    public bool RetirerMedia(int numeroReference)
    {
        var media = this[numeroReference];
        if (media != null)
        {
            Medias.Remove(media);
            return true;
        }
        return false;
    }
    
    public bool EmprunterMedia(int numeroReference, string utilisateur)
    {
        var media = this[numeroReference];
        if (media == null)
        {
            throw new MediaNotAvailableException($"Le média avec le numéro de référence {numeroReference} n'a pas été trouvé.");
        }
        if (media.NombreDExemplairesDisponibles <= 0)
        {
            throw new MediaNotAvailableException($"Le média avec le numéro de référence {numeroReference} n'est pas disponible pour l'emprunt.");
        }

        media -= 1;
        Emprunts.Add(new Emprunt
        {
            NumeroDeReference = numeroReference,
            Utilisateur = utilisateur,
            DateEmprunt = DateTime.Now
        });
        return true;
    }

    public bool RetournerMedia(int numeroReference, string utilisateur)
    {
        var media = this[numeroReference];
        if (media == null)
        {
            throw new MediaNotFoundException($"Le média avec le numéro de référence {numeroReference} n'a pas été trouvé.");
        }

        media += 1;
        var emprunt = Emprunts.FirstOrDefault(e => e.NumeroDeReference == numeroReference && e.Utilisateur == utilisateur);
        if (emprunt != null)
        {
            Emprunts.Remove(emprunt);
        }
        return true;
    }
    public List<Media> RechercherMedia(Func<Media, bool> critere)
    {
        return Medias.Where(critere).ToList();
    }
    
    public List<Media> ListerMedia(string utilisateur)
    {
        var numerosDeReference = Emprunts.Where(e => e.Utilisateur == utilisateur).Select(e => e.NumeroDeReference).ToList();
        return Medias.Where(m => numerosDeReference.Contains(m.NumeroDeReference)).ToList();
    }
    
    public void AfficherStatistiques()
    {
        int totalMedias = Medias.Count;
        int totalExemplairesDisponibles = Medias.Sum(media => media.NombreDExemplairesDisponibles);
        int totalExemplairesEmpruntes = Emprunts.Count;

        Console.WriteLine($"Nombre total de médias: {totalMedias}");
        Console.WriteLine($"Nombre total d'exemplaires disponibles: {totalExemplairesDisponibles}");
        Console.WriteLine($"Nombre total d'exemplaires empruntés: {totalExemplairesEmpruntes}");
    }
    public void SauvegarderBibliotheque(string cheminFichier)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(this, options);
        File.WriteAllText(cheminFichier, jsonString);
    }

    public static Library ChargerBibliotheque(string cheminFichier)
    {
        var jsonString = File.ReadAllText(cheminFichier);
        return JsonSerializer.Deserialize<Library>(jsonString);
    }
}
namespace TP1_QDev;

public class ProgrammePrincipal
{
    public static void Main(string[] args)
    {
        Library library = new Library();

        Media livre1 = new Media { Titre = "Livre 1", NumeroDeReference = 1, NombreDExemplairesDisponibles = 5 };
        Media livre2 = new Media { Titre = "Livre 2", NumeroDeReference = 2, NombreDExemplairesDisponibles = 3 };

        // Ajout de médias à la bibliothèque en utilisant l'opérateur +
        library.AjouterMedia(livre1 + 2); // Ajoute 2 exemplaires supplémentaires de livre1
        library.AjouterMedia(livre2 + 1); // Ajoute 1 exemplaire supplémentaire de livre2

        // Afficher les informations des médias dans la bibliothèque
        library.AfficherStatistiques();

        // Emprunter des médias
        try
        {
            if (library.EmprunterMedia(1, "Utilisateur1"))
            {
                Console.WriteLine("Emprunt réussi pour le média avec le numéro de référence 1.");
            }
        }
        catch (MediaNotFoundException ex)
        {
            Console.WriteLine($"Erreur: {ex.Message}");
        }
        catch (MediaNotAvailableException ex)
        {
            Console.WriteLine($"Erreur: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur inattendue lors de l'emprunt: {ex.Message}");
        }

        // Retourner des médias
        try
        {
            if (library.RetournerMedia(1, "Utilisateur1"))
            {
                Console.WriteLine("Retour réussi pour le média avec le numéro de référence 1.");
            }
        }
        catch (MediaNotFoundException ex)
        {
            Console.WriteLine($"Erreur: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur inattendue lors du retour: {ex.Message}");
        }

        // Afficher les informations des médias après les opérations d'emprunt et de retour
        library.AfficherStatistiques();

        // Afficher les informations de chaque média dans la bibliothèque
        foreach (var media in library.Medias)
        {
            media.AfficherInfos();
        }

        // Sauvegarder la bibliothèque
        try
        {
            string filePath = "bibliotheque.json";
            library.SauvegarderBibliotheque(filePath);
            Console.WriteLine("Bibliothèque sauvegardée.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la sauvegarde de la bibliothèque: {ex.Message}");
        }

        // Charger la bibliothèque
        try
        {
            string filePath = "bibliotheque.json";
            Library loadedLibrary = Library.ChargerBibliotheque(filePath);
            Console.WriteLine("Bibliothèque chargée.");

            // Afficher les informations de chaque média dans la bibliothèque chargée
            foreach (var media in loadedLibrary.Medias)
            {
                media.AfficherInfos();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du chargement de la bibliothèque: {ex.Message}");
        }
    }
}
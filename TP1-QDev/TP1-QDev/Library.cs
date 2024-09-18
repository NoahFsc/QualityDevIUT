namespace TP1_QDev;

public class Library
{
    public List<Media> Medias { get; set; } = new List<Media>();
    
    public Media this[int numeroReference]
    {
        get
        {
            return Medias.FirstOrDefault(media => media.NumeroDeReference == numeroReference);
        }
    }
}
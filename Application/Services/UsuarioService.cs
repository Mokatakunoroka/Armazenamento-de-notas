namespace Application.Service;
public class ServicosUsuario
{
    public bool UserExist(string usuario)
    {
        string bancoCarregado = File.ReadAllText(usuario);
        if (bancoCarregado.IndexOf(usuario) == 0)
        {
            return true;
        }
        else if (bancoCarregado.IndexOf(usuario) == bancoCarregado.IndexOf(usuario))
        {
            return true;
        }
        return false;
    }
}
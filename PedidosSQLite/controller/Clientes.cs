
public class Cliente {
    private String nome, email;

    
    public Cliente(String nome, String email) {
        setNome(nome);
        setEmail(email);
    }

    public void cadastroSucesso() {
        Console.WriteLine("Contato cadastrado com sucesso!");
    }

    public void cadastroErro(){
        Console.WriteLine("Erro ao cadastrar o contato!");
    }

    public String getNome() {
        return nome;
    }

    public String getEmail() {
        return email;
    }

    private void setNome(String nome) {
        this.nome = nome;
    }

    private void setEmail(String email) {
        this.email = email;
    }
}
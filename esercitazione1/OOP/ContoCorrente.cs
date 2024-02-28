class ContoCorrente : ContoBancario
{
    private double tasso;

    public ContoCorrente(string nome, double saldo, double tasso) : base(nome, saldo)
    {
        this.tasso = tasso;
    }

    public void CalcolaInteressi()
    {
        double interessi = Saldo * tasso / 100;
        Saldo -= interessi;
    }
}
namespace SOLID.Single_Responsibility_Principle
{
    public class Dba : Cargo
    {
        public Dba(IRegraDeCalculo regra) : base(regra)
        {
        }
    }
}
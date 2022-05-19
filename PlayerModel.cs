public class PlayerModel : IPlayerModel
{
    private readonly Guid _id = Guid.NewGuid();
    public Guid Id { get { return _id; } }
    public string Name { get; set; }
    public string Email { get; set; }

    public delegate void PrintPlayerInfo(PlayerModel playerModel);
    public void Print(PrintPlayerInfo function, PlayerModel player)
    {
        function(player);
    }
}
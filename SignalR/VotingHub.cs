namespace SignalR
{
    public class VotingHub : BaseHub, IVotingHubClient
    {
        private const string _changeSlide = "changeSlide";

        public async void ChangeSlide(short slideId)
        {
            await BroadcastMessage(_changeSlide, new object[] { slideId });
        }
    }
}

namespace Try.BL.Interface
{
    public interface IWishlistService
    {
        void ToggleWishlistItem(string userId, int apartmentid);
        int ClearWishlist(string userId);
        string GetWishlistId(string userId);
    }
}
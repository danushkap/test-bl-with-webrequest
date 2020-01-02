using System;
using System.Threading.Tasks;

namespace BL
{
    public class MembershipService
    {
        private readonly IWebRequestHandler _webRequestHandler;

        public MembershipService(IWebRequestHandler webRequestHandler)
        {
            _webRequestHandler = webRequestHandler;
        }

        /// <summary>
        /// This method returns MembershipType based on the membershipAmount paid by a member.
        /// </summary>
        /// <returns>
        /// if membershipAmount > 1000 then Platinum
        /// else if membershipAmount > 500 then Gold
        /// else if membershipAmount > 0 then Silver
        /// else NA
        /// </returns>
        public async Task<MembershipType> GetMembershipTypeAsync()
        {
            var result = await _webRequestHandler.GetStringAsync("https://realurl");

            var membershipAmount = Convert.ToInt32(result);

            if (membershipAmount > 1000) return MembershipType.Platinum;
            else if (membershipAmount > 500) return MembershipType.Gold;
            else if (membershipAmount > 0) return MembershipType.Silver;
            else return MembershipType.NA;
        }
    }
}

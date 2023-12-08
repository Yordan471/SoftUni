using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Utilities
{
    public class GlobalConstants
    {
        // Theatre
        public const int TheatreNameLengthMin = 4;
        public const int TheatreNameLengthMax = 30;
        public const sbyte TheatreNumberOfHallsMin = 1;
        public const sbyte TheatreNumberOfHallsMax = 10;
        public const int TheatreDirectorLengthMin = 4;
        public const int TheatreDirectorLengthMax = 30;

        // Play
        public const int PlayTitleLengthMin = 4;
        public const int PlayTitleLengthMax = 50;
        public const float PlayRatingMin = 0.0f;
        public const float PlayRatingMax = 10f;
        public const int PlayDescriptionLengthMax = 700;
        public const int PlayScreenwriterLengthMin = 4;
        public const int PlayScreenwriterLengthMax = 30;

        // Cast
        public const int CastFullNameLengthMin = 4;
        public const int CastFullNameLengthMax = 40;
        public const string CastPhoneNumberRegularExpressionValidation = @"\+44-\d{2}-\d{3}-\d{4}";

        // Ticket
        public const decimal TicketPriceMin = 1.00M;
        public const decimal TicketPriceMax = 100.00M;
        public const sbyte TicketRowNumberMin = 1;
        public const sbyte TicketRowNumberMax = 10;
    }
}

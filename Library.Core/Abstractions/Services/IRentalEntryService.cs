using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Abstractions
{
    public interface IRentalEntryService
    {
        List<RentalEntry> GetAllEntries();

        RentalEntry Rent(Title title, Member member);

        RentalEntry Return(RentalEntry entry);

        List<RentalEntry> GetByMember(int memberId);
    }
}

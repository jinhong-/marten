﻿using StructureMap;
using User = Marten.Testing.Documents.User;

namespace Marten.Testing.Examples
{
    public class IdentityMapTests : IntegratedFixture
    {
        // SAMPLE: using-identity-map
        public void using_identity_map()
        {

            var user = new User {FirstName = "Tamba", LastName = "Hali"};
            theStore.BulkInsert(new [] {user});

            // Open a document session with the identity map
            using (var session = theStore.OpenSession())
            {
                session.Load<User>(user.Id)
                    .ShouldBeTheSameAs(session.Load<User>(user.Id));
            }
        } 
        // ENDSAMPLE
    }
}
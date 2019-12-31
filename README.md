# How to test a method (BL) that contains a web request within ?

[![Build status](https://img.shields.io/appveyor/ci/danushkap/test-bl-with-webrequest?style=flat&logo=appveyor)](https://ci.appveyor.com/project/danushkap/test-bl-with-webrequest) [![CodeFactor](https://img.shields.io/codefactor/grade/github/danushkap/test-bl-with-webrequest?style=flat&logo=codefactor)](https://www.codefactor.io/repository/github/danushkap/test-bl-with-webrequest) [![Test status](https://img.shields.io/appveyor/tests/danushkap/test-bl-with-webrequest?style=flat&logo=appveyor)](https://ci.appveyor.com/project/danushkap/test-bl-with-webrequest/build/tests) [![Codecov](https://img.shields.io/codecov/c/github/danushkap/test-bl-with-webrequest?style=flat&logo=codecov)](https://codecov.io/gh/danushkap/test-bl-with-webrequest)

[![GitHub license](https://img.shields.io/github/license/danushkap/test-bl-with-webrequest?style=flat&logo=github)](https://github.com/danushkap/test-bl-with-webrequest/blob/master/LICENSE) [![GitHub issues](https://img.shields.io/github/issues/danushkap/test-bl-with-webrequest?style=flat&logo=github)](https://github.com/danushkap/test-bl-with-webrequest/issues)

Take a method (BL) that decide the membership type of a person based on the membership amount that he has paid. Where the method has to get the membership amount from a webservice.


```javascript
MembershipType GetMembershipType()
{
    var membershipAmount => () 
    {
        // get the membership amount from a webservice
    }
    
    if (membershipAmount > 1000) return MembershipType.Platinum;
    else if (membershipAmount > 500) return MembershipType.Gold;
    else if (membershipAmount > 0) return MembershipType.Silver;
    else return MembershipType.NA;
}
```

##### PROBLEM

Now how to test the business logic that is in the `GetMembershipType()` without having to worry about the webservice that it depends?

##### SOLUTION

Apply the Dependency Inversion principle : decouple the webservice dependency from the BL method. 
And apply the Dependency Injection design pattern to inject that dependency from outside.

See how this is done:

https://github.com/danushkap/test-bl-with-webrequest/blob/master/BL/MembershipService.cs

See how this design has enabled to test the business rules without having to worry about the webservice call:

https://github.com/danushkap/test-bl-with-webrequest/blob/master/BL.Tests/MembershipService_GetMembershipTypeAsync.cs

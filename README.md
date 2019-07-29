# Canducci.Recurrence

### Create Plan

#### VB.NET

```VB
Const clientId As String = ""
Const clientSecret As String = ""
Dim login = New Login(clientId, clientSecret)
Dim body = New Body("Plano Teste 001", 1, vbNull)
Dim plan = New Plans(login)
Dim planResponse As PlanResponse = plan.Create(body)
If planResponse.Status Then
    'planResponse.Code;
    'planResponse.Name;
    'planResponse.Interval;
    'planResponse.PlanId;
    'planResponse.Repeats;
    'planResponse.Status;
    'planResponse.CreatedAt;
End If
```

### Create Subscription
```VB
Const clientId As String = ""
Const clientSecret As String = ""
Dim login = New Login(clientId, clientSecret)
Dim subscriptions As New Subscriptions(login)
Dim subscriptionBody = New SubscriptionBody(
    New SubscriptionItem("Peso sobe medida 1kg", 5, 57D),
    New SubscriptionItem("Peso sobre medida 2kg", 5, 62)
    )
Dim subscriptionBodyResponse As SubscriptionBodyResponse =
    subscriptions.CreateSubscription(PlanResponse.PlanId, subscriptionBody)

If subscriptionBodyResponse.Status Then

End If
```

### Create Payment
#### BankingBillet - Boleto Bancário
```VB
Function CreateBankingBillet() As Object
    Dim BankingBillet = New BankingBillet()
    BankingBillet.Customer = New Customer()
    BankingBillet.Customer.Name = "User Teste"
    BankingBillet.Customer.CPF = "608.489.640-55"
    BankingBillet.Customer.Birth = Date.Now
    BankingBillet.Customer.Email = "user@user.com"
    BankingBillet.ExpireAt = Date.Now
    BankingBillet.Customer.Address = New Address With {
        .City = "Presidente Prudente",
        .Complement = "Casa - Residencial",
        .Neighborhood = "Bairro",
        .Number = "S/N",
        .State = "SP",
        .Street = "Rua A",
        .Zipcode = "19.200-000"
    }
    'BankingBillet.Customer.JuridicalPerson = New JuridicalPerson With {
    '    .CorporateName = "Razão Social",
    '    .CNPJ = "00.000.000/0001-00"
    '}
    BankingBillet.Customer.PhoneNumber = "1832326363"
    'BankingBillet.Discount = New Discount() With {
    '    .Type = DiscountType.Currency,
    '    .Value = 10
    '}
    'BankingBillet.ConditionalDiscount = New ConditionalDiscount() With {
    '    .Type = DiscountType.Currency,
    '    .Value = 11,
    '    .UntilDate = Date.Now
    '}
    'BankingBillet.Configurations = New Configurations() With {
    '    .Fine = 1,
    '    .Interest = 1
    '}
    BankingBillet.Message = "Bolete Bancário"
    Return BankingBillet
End Function

Dim bankingBillets As New BankingBillets(login)
Dim result = bankingBillets.Create(SubscriptionBodyResponse.SubscriptionId, CreateBankingBillet())

```
___

#### CreditCard - Cartão de Crédito
```VB
Function CreateCreditCard() As Object
    Dim CreditCar = New CreditCard()
    CreditCar.Customer = New Customer()
    CreditCar.Customer.Name = "User Teste"
    CreditCar.Customer.CPF = "111.111.111-11"
    CreditCar.Customer.Birth = Date.Now
    CreditCar.Customer.Email = "user@user.com"
    CreditCar.Customer.Address = New Address With {
        .City = "Presidente Prudente",
        .Complement = "Casa - Residencial",
        .Neighborhood = "Bairro",
        .Number = "S/N",
        .State = "SP",
        .Street = "Rua A",
        .Zipcode = "19.200-000"
    }
    CreditCar.Customer.JuridicalPerson = New JuridicalPerson With {
        .CorporateName = "Razão Social",
        .CNPJ = "00.000.000/0001-00"
    }
    CreditCar.Customer.PhoneNumber = "1832326363"
    CreditCar.BillingAddress = New BillingAddress With {
        .City = "Presidente Prudente",
        .Complement = "Casa - Residencial",
        .Neighborhood = "Bairro",
        .Number = "S/N",
        .State = "SP",
        .Street = "Rua A",
        .Zipcode = "19.200-000"
    }
    CreditCar.PaymentToken = "1234567890123456789012345678901234567890"
    CreditCar.Discount = New Discount() With {
        .Type = DiscountType.Currency,
        .Value = 10
    }
    CreditCar.Message = "Cartão de Crédito"
    CreditCar.TrialDays = Nothing
    Return CreditCar
End Function

Dim creditCards As New CreditCards(login)
Dim result = creditCards.Create(SubscriptionBodyResponse.SubscriptionId, CreateCreditCard())
```
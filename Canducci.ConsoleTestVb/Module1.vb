﻿Imports Canducci.Recurrence
Imports Canducci.Recurrence.EnumsType
Imports Canducci.Recurrence.Models
Imports Canducci.Recurrence.Responses
Module Module1
    Const clientId As String = "Client_Id_8d58dcde793202a58d6b7cfeb7a087a0800cb2f5"
    Const clientSecret As String = "Client_Secret_839ab219d1399476f7dee5ccf22bc08e08c874b9"
    Sub Main()
        ' Login Client
        Dim login As Login = Login.Create(clientId, clientSecret)
        '------------------------------------------------------------------------------

        ' Plans Instance
        'Dim plans As Plans = Plans.Create(login)
        'Dim plansItems = plans.Get(5560)
        'Dim d = plansItems

        ' Subscriptions Instance
        Dim subscriptions As New Subscriptions(login)
        Dim a = subscriptions.Get(32746)
        Dim b = a
        ' CreditCards Instance
        'Dim creditCards As New CreditCards(login)

        ' BankingBillets Instance
        '------------------------------------------------------------------------------
        'Dim bankingBillets As New BankingBillets(login)

        ' Create Plans
        'Dim PlanResponse = CreatePlan(plans)
        '------------------------------------------------------------------------------

        ' Creaate Subscriptions
        'Dim SubscriptionBodyResponse = CreateSubscription(subscriptions, PlanResponse.PlanId)
        '------------------------------------------------------------------------------
        'Dim result = bankingBillets.Create(SubscriptionBodyResponse.SubscriptionId, CreateBankingBillet())
        'Dim result = creditCards.Create(SubscriptionBodyResponse.SubscriptionId, CreateCreditCard())
    End Sub
    Function CreatePlan(ByVal plan As Plans) As PlanResponse(Of PlanResponseData)
        Dim body = New Body("Plano Teste 002", 1, Nothing)
        Return plan.Create(body)
    End Function
    Function CreateSubscription(ByVal Subscriptions As Subscriptions, ByVal planId As Integer) As SubscriptionBodyResponse
        Dim subscriptionBody = New SubscriptionBody(
            New SubscriptionItem("Roupa e Malhas", 100, 10D),
            New SubscriptionItem("Meias", 100, 11D),
            New SubscriptionItem("Cuecas", 100, 21D)
        )
        Return Subscriptions.Create(planId, subscriptionBody)
    End Function
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
End Module

# Canducci.Recurrence

### Create Plan

#### VB.NET

```VB
Const clientId As String = ""
Const clientSecret As String = ""
Dim login = New Login(clientId, clientSecret)
Dim plan = New Plan(login)
Dim body = New Body("Plano Teste 001", 1, vbNull)
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
Dim plan = New Plan(login)
Dim subscriptionBody = New SubscriptionBody(
    New SubscriptionItem("Peso sobe medida 1kg", 5, 57D),
    New SubscriptionItem("Peso sobre medida 2kg", 5, 62)
    )


Dim subscriptionBodyResponse As SubscriptionBodyResponse =
    plan.CreateSubscription(5560, subscriptionBody)

If subscriptionBodyResponse.Status Then

End If
```
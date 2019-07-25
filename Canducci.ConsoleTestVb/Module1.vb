Imports Canducci.Recurrence
Module Module1
    Const clientId As String = "Client_Id_8d58dcde793202a58d6b7cfeb7a087a0800cb2f5"
    Const clientSecret As String = "Client_Secret_839ab219d1399476f7dee5ccf22bc08e08c874b9"
    Sub Main()
        Dim login = New Login(clientId, clientSecret)
        Dim plan = New Plan(login)
        'CreatePlan(plan)
        'CreateSubscription(plan)
    End Sub
    Sub CreatePlan(ByVal plan As Plan)
        Dim body = New Body("Plano Teste 001", 1, Nothing)
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
    End Sub
    Sub CreateSubscription(ByVal plan As Plan)
        Dim subscriptionBody = New SubscriptionBody(
            New SubscriptionItem("Peso sobe medida 1kg", 5, 57D),
            New SubscriptionItem("Peso sobre medida 2kg", 5, 62)
            )


        Dim subscriptionBodyResponse As SubscriptionBodyResponse =
            plan.CreateSubscription(5560, subscriptionBody)

        If subscriptionBodyResponse.Status Then

        End If
    End Sub
End Module

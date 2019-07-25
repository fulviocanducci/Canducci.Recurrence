Imports Canducci.Recurrence
Module Module1
    Sub Main()
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
    End Sub
End Module

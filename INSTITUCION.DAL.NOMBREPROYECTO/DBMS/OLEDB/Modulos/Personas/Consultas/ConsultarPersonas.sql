SELECT T.NumeroFila, T.Id, T.Nombre, T.ApellidoPaterno, T.ApellidoMaterno, T.Sexo
FROM 
(
      SELECT  
      (
           SELECT COUNT(c2.Id) 
           FROM Personas AS c2 
           WHERE c2.Id <= c1.Id
      ) AS NumeroFila,
      c1.*    
    FROM Personas AS c1 
) T
WHERE T.NumeroFila BETWEEN [FilaInicial] AND [FilaFinal]
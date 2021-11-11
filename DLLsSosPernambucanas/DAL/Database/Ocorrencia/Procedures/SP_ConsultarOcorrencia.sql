﻿USE[DbSosPernambucanas]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ConsultarOcorrencia]
	@IdOcorrencia int
AS
BEGIN
	IF NOT EXISTS (Select			
		NOMeDENUNCIANTE,
		TELEFONeDENUNCIANTE,
		NUMERoTELEFONeLIGACAO,
		DESCRICAoTELEFONeLIGACAO,
		DESCRICAoOCORRENCIaLIGACAO		
		From Ocorrencia With(nolock) Where IdOCORRENCIA = @IdOcorrencia)			
	BEGIN
		Insert Into LogSistema Values ('Não existem ocorrencias cadastrados no sistema.', GETUTCDATE());
END
ELSE
	BEGIN
		Select			
		NOMeDENUNCIANTE,
		TELEFONeDENUNCIANTE,
		NUMERoTELEFONeLIGACAO,
		DESCRICAoTELEFONeLIGACAO,
		DESCRICAoOCORRENCIaLIGACAO		
		From Ocorrencia With(nolock) Where IdOCORRENCIA = @IdOcorrencia
	END
END
GO
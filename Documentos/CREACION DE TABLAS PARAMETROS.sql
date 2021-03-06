CREATE TABLE EVALUACION.CORRECION
(
	NU_ID_CORRECCION NUMERIC(10),
	[NU_ID_PRUEBA_PARTE] NUMERIC(10),
	[NU_ID_PREGUNTA] NUMERIC(10),
	[NU_ID_ALTERNATIVA] NUMERIC(10),
	NU_NRO_CORRECCION NUMERIC(10),
	VC_DESC_CORRECCION VARCHAR(50)
)

CREATE TABLE EVALUACION.CONVERSION
(
	NU_ID_CONVERSION NUMERIC(10),
	[NU_ID_PRUEBA_PARTE] NUMERIC(10),
	[NU_ID_PREGUNTA] NUMERIC(10),
	[NU_ID_ALTERNATIVA] NUMERIC(10),
	NU_PUNTAJE NUMERIC(10),
	NU_NRO_CORRECCION NUMERIC(10),
	VC_DESC_CORRECCION_CORTA VARCHAR(50),
	VC_DESC_CORRECCION VARCHAR(300),
	VC_DESC_GLOSA VARCHAR(5000),
	NU_WAIS1 NUMERIC(10),
	NU_WAIS2 NUMERIC(10),
	NU_WAIS3 NUMERIC(10),
	NU_WAIS4 NUMERIC(10),
	NU_WAIS5 NUMERIC(10)
)
CREATE TABLE EVALUACION.CLASIFICACION
(
	NU_ID_CLASIFICACION NUMERIC(10),
	[NU_ID_PRUEBA_PARTE] NUMERIC(10),
	NU_RANGO_MENOR_PD NUMERIC(10),
	NU_RANGO_MAYOR_PD NUMERIC(10),
	NU_RANGO_MENOR_PC NUMERIC(10),
	NU_RANGO_MAYOR_PC NUMERIC(10),
	NU_NIVEL NUMERIC(10),
	VC_DESC_CLASIFICACION VARCHAR(100),
	VC_DESC_DIAGNOSTICO VARCHAR(5000),
	VC_DESC_CONVERSION VARCHAR(100),
	VC_DESC_CONDICION VARCHAR(100)
)
CREATE TABLE EVALUACION.PATRON_PERFIL
(
	NU_ID_PATRON_PERFIL NUMERIC(10),
	NU_ID_CLASIFICACION NUMERIC(10),
	VC_DESC_CORTA_PATRON_PERFIL VARCHAR(100),
	VC_DESC_PATRON_PERFIL VARCHAR(300),
	VC_DESC_GLOSA VARCHAR(5000)
)
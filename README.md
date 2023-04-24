
![Logo](https://i.imgur.com/hg9syV1.png)

[![.NET version](https://img.shields.io/badge/.NET-7.0-blueviolet)](https://dotnet.microsoft.com/download/dotnet/7.0)
[![EntityFrameworkCore version](https://img.shields.io/badge/Entity%20Framework-6.4-blue.svg)](https://www.nuget.org/packages/EntityFramework/)
[![ASP.NET version](https://img.shields.io/badge/ASP.NET-7.0.2-blue.svg)](https://dotnet.microsoft.com/apps/aspnet)
[![Swagger version](https://img.shields.io/badge/Swagger-6.4.0-brightgreen.svg)](https://swagger.io/)
[![Newtonsoft.Json version](https://img.shields.io/badge/Newtonsoft.Json-13.0.3-blue.svg)](https://www.newtonsoft.com/json)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

<p align="center">
 <a href="#sobre">Sobre</a> •
 <a href="#features">Features</a> • 
 <a href="#doc">Documentação</a> • 
</p>

## Sobre <a name="#sobre"></a>

A API MedConnect é uma plataforma de comunicação entre profissionais de saúde e pacientes que visa melhorar a experiência e a qualidade do atendimento.
Ela permite que os profissionais de saúde gerenciem os pacientes e suas informações médicas e realizem consultas.
Por meio da MedConnect, pacientes podem acessar seu histórico de consultas médicas, permitindo um acompanhamento mais eficiente e digital.
Além disso, a API oferece integração com outras ferramentas populares, como o Swagger e o Newtonsoft Json, para uma melhor experiência de desenvolvimento.

## Features <a name="#features"></a>

- [x] Cadastro de pacientes
- [x] Cadastro de médicos
- [x] Cadastro de enfermeiros
- [x] Cadastro de consultas médicas

<br>

- [x] Informações sobre pacientes
- [x] Informações sobre médicos
- [x] Informações sobre enfermeiros

<br>

- [x] Histórico de consultas médicas


# Documentação da API

# AppointmentController
O AppointmentController é responsável pelo gerenciamento das consultas médicas (atendimentos) na API. Ele possui a rota /api/atendimentos e implementa o método **HTTP PUT NewAppointment**.

O método **NewAppointment** é responsável por criar um novo atendimento a partir dos dados fornecidos pelo usuário.

<br>

## Endpoint `/api/atendimentos`
Este endpoint é responsável por criar um novo atendimento médico.

#### Requisição
**PUT** `/api/atendimentos`


#### Request Body

```json
{
    "doctorModelId": 1,
    "patientModelId": 2,
    "description": "Consulta de rotina"
}
```

<table>
  <thead>
    <tr>
      <th>Campo</th>
      <th>Tipo</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>DoctorModelId</td>
      <td>int</td>
      <td>ID do médico responsável pelo atendimento</td>
    </tr>
    <tr>
      <td>PatientModelId</td>
      <td>int</td>
      <td>ID do paciente que será atendido</td>
    </tr>
    <tr>
      <td>Description</td>
      <td>string</td>
      <td>Descrição do atendimento</td>
    </tr>
  </tbody>
</table>

#### Resposta
Em caso de sucesso, o método retorna o objeto AppointmentDto criado. Caso contrário, retorna um código HTTP de erro e uma mensagem de erro descritiva.

#### Exemplo de retorno em caso de sucesso

```json
{
    "DoctorModelId": 1,
    "PatientModelId": 2,
    "Description": "Consulta de rotina"
}
```

#### Possíveis status de retorno

<table>
  <thead>
    <tr>
      <th>Código de Status</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>200</td>
      <td>OK - Requisição executada com sucesso</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Bad Request - Campos preenchidos de forma incorreta</td>
    </tr>
    <tr>
      <td>404</td>
      <td>Not Found - Paciente ou Médico não encontrados</td>
    </tr>
  </tbody>
</table>

<br>

# PatientController

O PatientController é responsável pelo gerenciamento dos pacientes na API.

### Endpoint `/api/pacientes`
Este endpoint é responsável por realizar operações relacionadas aos pacientes cadastrados no sistema, como cadastrar, consultar, atualizar e excluir pacientes.

## [HttpGet]

O método **GetPatient** é responsável por consultar todos os pacientes cadastrados no sistema e pode receber como parâmetro o status de atendimento dos pacientes,
para buscar por pacientes apenas com o status de atendimento inserido.

#### Requisição
**GET** `/api/pacientes?status=`
#### Parâmetros
`status` (opcional) - O status de atendimento do paciente. Os possíveis valores são: **AGUARDANDO_ATENDIMENTO, EM_ATENDIMENTO, NAO_ATENDIDO, ATENDIDO**

O método **GetPatientByID** é responsável por consultar um paciente específico a partir do ID fornecido pelo usuário.
#### Requisição
**GET** `/api/pacientes{id}`

<br>

#### Resposta
Em caso de sucesso, o método retorna um objeto PatientDto ou uma lista de objetos PatientDto contendo as informações dos pacientes consultados. Caso contrário, retorna um código HTTP de erro e uma mensagem de erro descritiva.

```json
{
    "emergencyContact": "91365777069",
    "allergies": [
      "Amendoim",
      "Aspirina"
    ],
    "specificCares": [
      "Hipertensão"
    ],
    "insurance": "Amil",
    "attendanceStatus": "ATENDIDO",
    "appointmentCount": 2,
    "appointments": [
      {
        "id": 1,
        "patientModelId": 1,
        "doctorModelId": 1,
        "description": "Consulta de rotina"
      },
      {
        "id": 2,
        "patientModelId": 1,
        "doctorModelId": 2,
        "description": "Exame de sangue"
      }
    ],
    "id": 1,
    "name": "João Silva",
    "gender": "Masculino",
    "birthDate": "1985-10-15T22:15:58",
    "cpf": "12874145871",
    "phoneNumber": "91986850045"
  }    
```

<table>
  <thead>
    <tr>
      <th>Campo</th>
      <th>Tipo</th>
      <th>Obrigatório</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Name</td>
      <td>string</td>
      <td>Sim</td>
      <td>Nome completo do paciente</td>
    </tr>
    <tr>
      <td>CPF</td>
      <td>string</td>
      <td>Sim</td>
      <td>CPF do paciente (somente números)</td>
    </tr>
    <tr>
      <td>Gender</td>
      <td>string</td>
      <td>Sim</td>
      <td>Gênero do paciente</td>
    </tr>
    <tr>
      <td>PhoneNumber</td>
      <td>string</td>
      <td>Não</td>
      <td>Número de telefone do paciente</td>
    </tr>
    <tr>
      <td>BirthDate</td>
      <td>DateTime</td>
      <td>Sim</td>
      <td>Data de nascimento do paciente</td>
    </tr>
    <tr>
      <td>EmergencyContact</td>
      <td>string</td>
      <td>Não</td>
      <td>Número do contato de emergência do paciente</td>
    </tr>
    <tr>
      <td>Allergies</td>
      <td>string</td>
      <td>Não</td>
      <td>Alergias que o paciente possui</td>
    </tr>
    <tr>
      <td>SpecificCares</td>
      <td>string</td>
      <td>Não</td>
      <td>Cuidados específicos que o paciente precisa</td>
    </tr>
    <tr>
      <td>Insurance</td>
      <td>string</td>
      <td>Não</td>
      <td>Convênio médico do paciente</td>
    </tr>
    <tr>
      <td>AttendanceStatus</td>
      <td>string</td>
      <td>Não</td>
      <td>Status de atendimento do paciente (AGUARDANDO_ATENDIMENTO, EM_ATENDIMENTO, NAO_ATENDIDO, ATENDIDO)</td>
    </tr>
  </tbody>
</table>

#### Possíveis status de retorno

<table>
  <thead>
    <tr>
      <th>Método</th>
      <th>Status</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td rowspan="2">GetPatient</td>
      <td>200</td>
      <td>Retorna uma lista de objetos <code>PatientDto</code>.</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Retorna uma mensagem de erro caso ocorra algum problema com a solicitação.</td>
    </tr>
   <tr>
      <td rowspan="2">GetPatientByID</td>
      <td>200</td>
      <td>Retorna um objeto <code>PatientDto</code> correspondente ao ID informado.</td>
    </tr>
    <tr>
      <td>404</td>
      <td>Retorna uma mensagem de erro caso não seja encontrado um paciente com o ID informado.</td>
    </tr>
  </tbody>
</table>

<br>

## [HttpPost]
O método **PostPatient** é responsável por cadastrar pacientes no sistema.

#### Requisição
**POST** `/api/pacientes`
Essa requisição permite cadastrar um novo paciente no sistema.

#### Request Body

```json
{
  "name": "string",
  "gender": "string",
  "birthDate": "2023-04-24T15:03:26.399Z",
  "cpf": "40226913001",
  "phoneNumber": "stringstrin",
  "emergencyContact": "stringstrin",
  "allergies": [
    "string"
  ],
  "specificCares": [
    "string"
  ],
  "insurance": "string",
  "attendanceStatus": "AGUARDANDO_ATENDIMENTO"
}
```

#### Possíveis status de retorno

<table>
  <thead>
    <tr>
      <th>Status</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>201</td>
      <td>Indica que o cadastro do paciente foi realizado com sucesso.</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Indica que há campos preenchidos de forma incorreta.</td>
    </tr>
    <tr>
      <td>409</td>
      <td>Indica que o CPF já está cadastrado no sistema.</td>
    </tr>
  </tbody>
</table>

<br>

## [HttpPatch]
O método **UpdateAttendanceStatus** é responsável por atualizar o status de atendimento do paciente.

#### Requisição

**PATCH** `/api/pacientes/{id}/status`

Essa requisição permite a atualização do status de atendimento de um paciente já cadastrado no sistema.


#### Parâmetros

`id` (obrigatório): identificador numérico do paciente.


#### Request Body


```json
{
    "AttendanceStatus": "ATENDIDO"
}
```
<table>
  <thead>
    <tr>
      <th>Campo</th>
      <th>Tipo</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td>
      <td>int</td>
      <td>Identificador único do paciente.</td>
    </tr>
    <tr>
      <td>AttendanceStatus</td>
      <td>string</td>
      <td>Status de atendimento do paciente (AGUARDANDO_ATENDIMENTO, EM_ATENDIMENTO, NAO_ATENDIDO, ATENDIDO)</td>
    </tr>
  </tbody>
</table>


#### Possíveis status de retorno

<table>
  <thead>
    <tr>
      <th>Código de status</th>
      <th>Descrição</th>
      <th>Corpo da resposta</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>200</td>
      <td>Status de atendimento atualizado com sucesso.</td>
      <td>Objeto PatchPatientDto com o novo status de atendimento.</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Campos preenchidos de forma incorreta.</td>
      <td>Mensagem de erro.</td>
    </tr>
    <tr>
      <td>404</td>
      <td>Paciente não encontrado.</td>
      <td>Mensagem de erro.</td>
    </tr>
  </tbody>
</table>

<br>

## [HttpDelete]
O método DeletePatient é responsável por excluir um paciente cadastrado no sistema.

#### Requisição
**DELETE** `/api/pacientes/{id}`
Essa requisição permite a exclusão de um paciente já cadastrado no sistema.

#### Parâmetros
`id` (obrigatório): identificador numérico do paciente a ser excluído.

#### Possíveis status de retorno
<table>
  <thead>
    <tr>
      <th>Código de status</th>
      <th>Descrição</th>
      <th>Corpo da resposta</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>204</td>
      <td>Paciente excluído com sucesso.</td>
      <td></td>
    </tr>
    <tr>
      <td>404</td>
      <td>Paciente não encontrado.</td>
      <td>Mensagem de erro.</td>
    </tr>
  </tbody>
</table>

<br>

#DoctorController

O DoctorController é responsável pelo gerenciamento dos médicos na API.

### Endpoint `/api/medicos`
Este endpoint é responsável por realizar operações relacionadas aos médicos cadastrados no sistema, como cadastrar, consultar, atualizar e excluir.

## [HttpGet]

O método **GetDoctors** é responsável por consultar todos os médicos cadastrados no sistema e pode receber como parâmetro o estado no sistema,
para buscar por médicos apenas com o estado inserido.

#### Requisição
**GET** `/api/medicos?status=`
#### Parâmetros
status (opcional) - O estado no sistema do médico. Os possíveis valores são: **INATIVO e ATIVO**

<br>

O método **GetDoctorById** é responsável por consultar um médico específico a partir do ID fornecido pelo usuário.
#### Requisição
**GET** `/api/medicos{id}`


#### Resposta
Em caso de sucesso, o método retorna um objeto DoctorDto ou uma lista de objetos DoctorDto contendo as informações dos médicos consultados.
Caso contrário, retorna um código HTTP de erro e uma mensagem de erro descritiva.

```json
{
    "educationalInstitution": "Universidade de São Paulo",
    "crmUf": "87458/SC",
    "clinicalSpecialization": "CLINICO_GERAL",
    "statusInSystem": "ATIVO",
    "appointmentCount": 7,
    "appointments": [
      {
        "id": 1,
        "patientModelId": 1,
        "doctorModelId": 1,
        "description": "Consulta de rotina"
      }
    ],
    "id": 1,
    "name": "Carlos Silva Antunes",
    "gender": "Masculino",
    "birthDate": "1980-01-01T00:00:00",
    "cpf": "60544567099",
    "phoneNumber": "71997437590"
  }
```

<table>
  <thead>
    <tr>
      <th>Campo</th>
      <th>Tipo</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
   <tr>
      <td>Name</td>
      <td>string</td>
      <td>Nome completo do médico.</td>
    </tr>
    <tr>
      <td>Gender</td>
      <td>string</td>
      <td>Gênero do médico.</td>
    </tr>
    <tr>
      <td>BirthDate</td>
      <td>datetime</td>
      <td>Data de nascimento do médico.</td>
    </tr>
    <tr>
      <td>Cpf</td>
      <td>string</td>
      <td>CPF (Cadastro de Pessoas Físicas) do médico.</td>
    </tr>
    <tr>
      <td>PhoneNumber</td>
      <td>string</td>
      <td>Número de telefone do médico.</td>
    </tr>
    <tr>
      <td>EducationalInstitution</td>
      <td>string</td>
      <td>Instituição de ensino onde o médico se formou.</td>
    </tr>
    <tr>
      <td>CrmUf</td>
      <td>string</td>
      <td>Número do Conselho Regional de Medicina do médico seguido da sigla do estado em que foi emitido.</td>
    </tr>
    <tr>
      <td>ClinicalSpecialization</td>
      <td>string</td>
      <td>Especialização clínica do médico.</td>
    </tr>
    <tr>
      <td>StatusInSystem</td>
      <td>string</td>
      <td>Status do médico no sistema (ATIVO ou INATIVO).</td>
    </tr>
    <tr>
      <td>AppointmentCount</td>
      <td>int</td>
      <td>Número de consultas realizadas pelo médico.</td>
    </tr>
    <tr>
      <td>appointments</td>
      <td>array</td>
      <td>Lista de consultas realizadas pelo médico.</td>
    </tr>
    <tr>
      <td>Id</td>
      <td>int</td>
      <td>Identificador único do médico.</td>
    </tr>
  </tbody>
</table>



#### Possíveis status de retorno
<table>
  <thead>
    <tr>
      <th>Método</th>
      <th>Status</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td rowspan="2">GetDoctors</td>
      <td>200</td>
      <td>Retorna uma lista de objetos <code>DoctorDto</code>.</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Retorna uma mensagem de erro caso ocorra algum problema com a solicitação.</td>
    </tr>
   <tr>
      <td rowspan="2">GetDoctorById</td>
      <td>200</td>
      <td>Retorna um objeto <code>DoctorDto</code> correspondente ao ID informado.</td>
    </tr>
    <tr>
      <td>404</td>
      <td>Retorna uma mensagem de erro caso não seja encontrado um médico com o ID informado.</td>
    </tr>
  </tbody>
</table>

<br>

## [HttpPost]
O método **DoctorPost** é responsável por cadastrar médicos no sistema.

<br>

#### Requisição
**POST** `/api/medicos`
Essa requisição permite cadastrar um novo médico no sistema.

#### Request Body

```json
{
  "name": "string",
  "gender": "string",
  "birthDate": "2023-04-24T16:07:46.620Z",
  "cpf": "22569319751",
  "phoneNumber": "stringstrin",
  "educationalInstitution": "string",
  "crmUf": "string",
  "clinicalSpecialization": "CLINICO_GERAL",
  "statusInSystem": "ATIVO"
}
```

<table>
  <thead>
    <tr>
      <th>Campo</th>
      <th>Tipo</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
   <tr>
      <td>Name</td>
      <td>string</td>
      <td>Nome completo do médico.</td>
    </tr>
    <tr>
      <td>Gender</td>
      <td>string</td>
      <td>Gênero do médico.</td>
    </tr>
    <tr>
      <td>BirthDate</td>
      <td>datetime</td>
      <td>Data de nascimento do médico.</td>
    </tr>
    <tr>
      <td>Cpf</td>
      <td>string</td>
      <td>CPF (Cadastro de Pessoas Físicas) do médico.</td>
    </tr>
    <tr>
      <td>PhoneNumber</td>
      <td>string</td>
      <td>Número de telefone do médico.</td>
    </tr>
    <tr>
      <td>EducationalInstitution</td>
      <td>string</td>
      <td>Instituição de ensino onde o médico se formou.</td>
    </tr>
    <tr>
      <td>CrmUf</td>
      <td>string</td>
      <td>Número do Conselho Regional de Medicina do médico seguido da sigla do estado em que foi emitido.</td>
    </tr>
    <tr>
      <td>ClinicalSpecialization</td>
      <td>string</td>
      <td>Especialização clínica do médico.</td>
    </tr>
    <tr>
      <td>StatusInSystem</td>
      <td>string</td>
      <td>Status do médico no sistema (ATIVO ou INATIVO).</td>
    </tr>
    <tr>
      <td>AppointmentCount</td>
      <td>int</td>
      <td>Número de consultas realizadas pelo médico.</td>
    </tr>
    <tr>
      <td>appointments</td>
      <td>array</td>
      <td>Lista de consultas realizadas pelo médico.</td>
    </tr>
    <tr>
      <td>Id</td>
      <td>int</td>
      <td>Identificador único do médico.</td>
    </tr>
  </tbody>
</table>

#### Possíveis status de retorno

<table>
  <thead>
    <tr>
      <th>Status</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>201</td>
      <td>Indica que o cadastro do médico foi realizado com sucesso.</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Indica que há campos preenchidos de forma incorreta.</td>
    </tr>
    <tr>
      <td>409</td>
      <td>Indica que o CPF já está cadastrado no sistema.</td>
    </tr>
  </tbody>
</table>

## [HttpPatch]
O método **UpdateAttendanceStatus** é responsável por atualizar o status de atendimento do paciente.

#### Requisição

**PATCH** `/api/pacientes/{id}/status`

Essa requisição permite a atualização do status de atendimento de um paciente já cadastrado no sistema.


#### Parâmetros

`id` (obrigatório): identificador numérico do paciente.


#### Request Body
```json
{
  "statusInSystem": "ATIVO"
}
```
<table>
  <thead>
    <tr>
      <th>Campo</th>
      <th>Tipo</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td>
      <td>int</td>
      <td>Identificador único do médico.</td>
    </tr>
    <tr>
      <td>StatusInSystem</td>
      <td>string</td>
      <td>Estado no Sistema do médico (ATIVO, INATIVO)</td>
    </tr>
  </tbody>
</table>

#### Possíveis status de retorno

<table>
  <thead>
    <tr>
      <th>Código de status</th>
      <th>Descrição</th>
      <th>Corpo da resposta</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>200</td>
      <td>Estado no sistema atualizado com sucesso.</td>
      <td>Objeto UpdateDoctor com o novo estado no sistema.</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Campos preenchidos de forma incorreta.</td>
      <td>Mensagem de erro.</td>
    </tr>
    <tr>
      <td>404</td>
      <td>Médico não encontrado.</td>
      <td>Mensagem de erro.</td>
    </tr>
  </tbody>
</table>

## [HttpDelete]
O método DeleteDoctor é responsável por excluir um médico cadastrado no sistema.

#### Requisição
**DELETE** `/api/medicos/{id}`
Essa requisição permite a exclusão de um médico já cadastrado no sistema.

#### Parâmetros
`id` (obrigatório): identificador numérico do médico a ser excluído.

#### Possíveis status de retorno
<table>
  <thead>
    <tr>
      <th>Código de status</th>
      <th>Descrição</th>
      <th>Corpo da resposta</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>204</td>
      <td>Médico excluído com sucesso.</td>
      <td></td>
    </tr>
    <tr>
      <td>404</td>
      <td>Médico não encontrado.</td>
      <td>Mensagem de erro.</td>
    </tr>
  </tbody>
</table>

<br>

# NurseController

### Endpoint `/api/enfermeiros`
Este endpoint é responsável por realizar operações relacionadas aos enfermeiros cadastrados no sistema, como cadastrar, consultar, atualizar e excluir.

## [HttpGet]

O método **GetNurses** é responsável por consultar todos os enfermeiros cadastrados no sistema.

#### Requisição
**GET** `/api/enfermeiros`

<br>

O método **GetNurseById** é responsável por consultar um enfermeiro específico a partir do ID fornecido pelo usuário.
#### Requisição
**GET** `/api/enfermeiro{id}`

#### Resposta
Em caso de sucesso, o método retorna um objeto NurseDto ou uma lista de objetos NurseDto contendo as informações dos enfermeiros consultados.
Caso contrário, retorna um código HTTP de erro e uma mensagem de erro descritiva.

```json
  {
    "educationalInstitution": "Escola de Enfermagem da Universidade de São Paulo",
    "cofenUf": "123456/SP",
    "id": 1,
    "name": "Julia Silva",
    "gender": "Feminino",
    "birthDate": "1990-05-20T00:00:00",
    "cpf": "89924802020",
    "phoneNumber": "92993448986"
  }
```

<table>
  <thead>
    <tr>
      <th>Campo</th>
      <th>Tipo</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
   <tr>
      <td>Name</td>
      <td>string</td>
      <td>Nome completo do enfermeiro.</td>
    </tr>
    <tr>
      <td>Gender</td>
      <td>string</td>
      <td>Gênero do enfermeiro.</td>
    </tr>
    <tr>
      <td>BirthDate</td>
      <td>datetime</td>
      <td>Data de nascimento do enfermeiro.</td>
    </tr>
    <tr>
      <td>Cpf</td>
      <td>string</td>
      <td>CPF (Cadastro de Pessoas Físicas) do enfermeiro.</td>
    </tr>
    <tr>
      <td>PhoneNumber</td>
      <td>string</td>
      <td>Número de telefone do enfermeiro.</td>
    </tr>
    <tr>
      <td>EducationalInstitution</td>
      <td>string</td>
      <td>Instituição de ensino onde o enfermeiro se formou.</td>
    </tr>
    <tr>
      <td>CofenUf</td>
      <td>string</td>
      <td>Número do Conselho Federal de Enfermagem do enfermeiro seguido da sigla do estado em que foi emitido.</td>
    </tr>
         <td>Id</td>
      <td>int</td>
      <td>Identificador único do Enfermeiro.</td>
    </tr>
  </tbody>
</table>

#### Possíveis status de retorno
<table>
  <thead>
    <tr>
      <th>Método</th>
      <th>Status</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td rowspan="2">GetNurses</td>
      <td>200</td>
      <td>Retorna uma lista de objetos <code>NurseDto</code>.</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Retorna uma mensagem de erro caso ocorra algum problema com a solicitação.</td>
    </tr>
   <tr>
      <td rowspan="2">GetNursesById</td>
      <td>200</td>
      <td>Retorna um objeto <code>NurseDto</code> correspondente ao ID informado.</td>
    </tr>
    <tr>
      <td>404</td>
      <td>Retorna uma mensagem de erro caso não seja encontrado um enfermeiro com o ID informado.</td>
    </tr>
  </tbody>
</table>

<br>

## [HttpPost]
O método **NursePost** é responsável por cadastrar enfermeiros no sistema.

<br>

#### Requisição
**POST** `/api/enfermeiros`
Essa requisição permite cadastrar um novo enfermeiro no sistema.

#### Request Body
```json
{
  "name": "string",
  "gender": "string",
  "birthDate": "2023-04-24T16:26:37.833Z",
  "cpf": "40278284235",
  "phoneNumber": "stringstrin",
  "educationalInstitution": "string",
  "cofenUf": "string"
}
```

<table>
  <thead>
    <tr>
      <th>Campo</th>
      <th>Tipo</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
   <tr>
      <td>Name</td>
      <td>string</td>
      <td>Nome completo do enfermeiro.</td>
    </tr>
    <tr>
      <td>Gender</td>
      <td>string</td>
      <td>Gênero do enfermeiro.</td>
    </tr>
    <tr>
      <td>BirthDate</td>
      <td>datetime</td>
      <td>Data de nascimento do enfermeiro.</td>
    </tr>
    <tr>
      <td>Cpf</td>
      <td>string</td>
      <td>CPF (Cadastro de Pessoas Físicas) do enfermeiro.</td>
    </tr>
    <tr>
      <td>PhoneNumber</td>
      <td>string</td>
      <td>Número de telefone do enfermeiro.</td>
    </tr>
    <tr>
      <td>EducationalInstitution</td>
      <td>string</td>
      <td>Instituição de ensino onde o enfermeiro se formou.</td>
    </tr>
    <tr>
      <td>CofenUf</td>
      <td>string</td>
      <td>Número do Conselho Federal de Enfermagem do enfermeiro seguido da sigla do estado em que foi emitido.</td>
    </tr>
         <td>Id</td>
      <td>int</td>
      <td>Identificador único do Enfermeiro.</td>
    </tr>
  </tbody>
</table>

#### Possíveis status de retorno

<table>
  <thead>
    <tr>
      <th>Status</th>
      <th>Descrição</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>201</td>
      <td>Indica que o cadastro do enfermeiro foi realizado com sucesso.</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Indica que há campos preenchidos de forma incorreta.</td>
    </tr>
    <tr>
      <td>409</td>
      <td>Indica que o CPF já está cadastrado no sistema.</td>
    </tr>
  </tbody>
</table>

#### Requisição
**DELETE** `/api/enfermeiros/{id}`
Essa requisição permite a exclusão de um enfermeiro já cadastrado no sistema.

#### Parâmetros
`id` (obrigatório): identificador numérico do enfermeiro a ser excluído.

#### Possíveis status de retorno
<table>
  <thead>
    <tr>
      <th>Código de status</th>
      <th>Descrição</th>
      <th>Corpo da resposta</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>204</td>
      <td>Enfermeiro excluído com sucesso.</td>
      <td></td>
    </tr>
    <tr>
      <td>404</td>
      <td>Enfermeiro não encontrado.</td>
      <td>Mensagem de erro.</td>
    </tr>
  </tbody>
</table>

<br>
# ValidarCpfCnpj


#### Explicação de validação de CPF e CNPJ [neste link](https://campuscode.com.br/conteudos/o-calculo-do-digito-verificador-do-cpf-e-do-cnpj#:~:text=O%20c%C3%A1lculo%20de%20valida%C3%A7%C3%A3o%20do,2%20e%20somamos%20esse%20resultado.)

Números repetidos passam na validação básica. 
Ex: 00000000000, 11111111111, 22222222222, etc
Passam tanto na validação do CPF quanto do CNPJ. Por isso precisamos antes verificar se todos os caracteres são iguais, e invalidar.

#### Código completo no arquivo 'Validar.cs'

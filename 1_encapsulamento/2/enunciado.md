Exercício: Sistema de Conta Bancária (enunciado gerado pelo claude)

Contexto
Você vai criar uma classe ContaBancaria que representa uma conta de banco simples, aplicando encapsulamento para proteger os dados e controlar as operações.
Requisitos
Campos privados:

_numeroConta (string)
_saldo (decimal)
_titular (string)

Propriedades públicas:

NumeroConta → somente leitura (sem setter)
Titular → com getter e setter, mas o setter não deve aceitar string vazia ou nula
Saldo → somente leitura

Métodos públicos:

Depositar(decimal valor) → rejeita valores negativos ou zero
Sacar(decimal valor) → rejeita valores negativos, maiores que o saldo, e maiores que o limite de saque
ExibirResumo() → imprime os dados da conta no console


Desafio extra
Crie um método TransferirPara(ContaBancaria destino, decimal valor) que usa os métodos Sacar e Depositar internamente, sem acessar os campos privados diretamente.

O que praticar aqui

Proteção de estado interno com campos privados
Validação dentro de setters e métodos
Exposição controlada de dados via propriedades
Reutilização de lógica encapsulada no método de transferência	
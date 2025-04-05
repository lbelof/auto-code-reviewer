# 🧠 AutoCodeReviewer

**AutoCodeReviewer** é um serviço backend que automatiza a revisão de código-fonte em **Pull Requests do Azure DevOps**, utilizando a **API do ChatGPT (OpenAI)** para gerar sugestões, alertas e insights sobre as alterações realizadas.

Com ele, sua equipe ganha um assistente de code review 24/7 — apontando problemas, elogiando boas práticas e sugerindo melhorias com base em inteligência artificial.

---

## ⚙️ Como funciona

1. Um **webhook** é disparado no Azure DevOps ao criar ou atualizar um Pull Request.
2. O serviço captura os dados do PR e o **diff de código** via Azure DevOps REST API.
3. Um **prompt técnico** é montado com o conteúdo do PR e enviado à API do ChatGPT.
4. A resposta da IA é interpretada e **publicada no próprio PR** como comentário automatizado.

---

## 📦 Tecnologias utilizadas

- **.NET 8** – Backend com ASP.NET Core Web API
- **Azure DevOps REST API** – Consulta de PRs e diffs
- **OpenAI GPT API** – Análise de código via IA
- (opcional) **Kafka** – Para orquestração assíncrona
- (opcional) **MongoDB / DynamoDB** – Histórico de análises
- (opcional) **AWS Lambda / ECS** – Deploy escalável

---

## 🔄 Fluxo de arquitetura

```text
[Azure DevOps Webhook]
           ↓
[AutoCodeReviewer API (.NET)]
           ↓
[Consulta PR + Diff (Azure DevOps API)]
           ↓
[Montagem do Prompt]
           ↓
[Análise com ChatGPT (OpenAI API)]
           ↓
[Comentário no PR ou retorno via API]

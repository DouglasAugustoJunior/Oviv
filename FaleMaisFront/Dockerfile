# Baseado em node na última versão
FROM node:latest as node
# Autor
LABEL Douglas Augusto Junior
# Pasta que vai pegar os arquivos e pasta destino
COPY . /FaleMaisFront
# Diretório que ele vai trabalhar, onde vai rodar o start
WORKDIR /FaleMaisFront
# Comando inicial para instalar dependências
RUN npm install
RUN npm run build --omit=dev

# Baseado no nginx
FROM nginx
COPY --from=node /FaleMaisFront/dist/fale-mais-front /usr/share/nginx/html
# Substitui env.js pelo env.template com a URL informada no env do docker
CMD ["/bin/sh",  "-c",  "envsubst < /usr/share/nginx/html/assets/env.template.js > /usr/share/nginx/html/assets/env.js && exec nginx -g 'daemon off;'"]
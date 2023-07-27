FROM node:alpine as builder
WORKDIR /app
COPY package.json .
COPY yarn.lock .
RUN yarn install
COPY . .
RUN yarn build

FROM nginx as production
WORKDIR /usr/share/nginx/html
COPY --from=builder /app/dist/ .
EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]

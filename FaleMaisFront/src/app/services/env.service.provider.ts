import { EnvironmentService } from "./enviroment.service"

const _env:any = '__env'
export const EnvServiceFactory = () => {
    const environment:any = new EnvironmentService()

    const browserWindow:any = window || {}
    const browserWindowEnvironment:[] = browserWindow[_env] || {}

    for (const key in browserWindowEnvironment) {
        if (browserWindowEnvironment.hasOwnProperty(key))
            environment[key] = window[_env][key]
    }
    return environment
}

export const EnvServiceProvider = {
    provide: EnvironmentService,
    useFactory: EnvServiceFactory,
    deps: []
}
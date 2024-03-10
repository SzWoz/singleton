class Logger{
    constructor(){
        if(Logger.exists) return Logger.instance

        this.logs = []
        Logger.instance = this
    }

    static getInstance(){
        return Logger.instance || new Logger()
    }

    registerMessage(message){
        this.logs.push(message)
    }

    displayLogs(){
        console.log('Logged Messages')
        this.logs.forEach((message, index)=>{
            console.log(`${index+1}. ${message}`)
        })
    }
}

const logger = Logger.getInstance();
logger.registerMessage("Pierwszy komunikat");
logger.registerMessage("Drugi komunikat");
logger.registerMessage('Trzeci')
logger.displayLogs();

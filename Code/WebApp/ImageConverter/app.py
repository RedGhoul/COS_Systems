from flask import Flask
import mritopng
app = Flask(__name__)


@app.route('/')
def hello_world():
    return 'YOLO LYFE'

if __name__ == '__main__':
    app.run()